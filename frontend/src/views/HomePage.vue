<template>
    <div class="container">
        <div v-if="!appointment_list.length" class="table-placeholder">
            <TablePlaceholder />
        </div>
        <div v-else class="row">
            <div  class="search mb-5 p-0">
                <form class="w-100 me-3" role="search">
                    <input type="search" v-model="search" class="form-control p-3" placeholder="Hastaya göre randevu ara..." aria-label="Search">
                </form>
            </div>

            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Hasta</th>
                        <th scope="col">Personel</th>
                        <th scope="col">Tarih</th>
                        <th scope="col">Saat</th>
                        <th scope="col">Hizmetler</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(appointment, index) in filteredList" :key="index">
                        <th scope="row">{{ index + 1 }}</th>
                        <td>{{ appointment.patientName }}</td>
                        <td>{{ (appointment.staffName).split("_")[0] + " " + (appointment.staffName).split("_")[1] }}</td>
                        <td>{{ appointment.appointmentDate.split(" ")[0] }}</td>
                        <td>{{ appointment.appointmentDate.split(" ")[1] }}</td>
                        <td>Kanal Tedavisi | Genel Muayene | Ortodonti</td>
                        <td class="d-flex justify-content-end"><DeleteModal @delete-event="deleteAppointment(appointment)"/></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import DeleteModal from "../components/DeleteModal.vue"
import TablePlaceholder from "../components/TablePlaceholder.vue"

export default {
  name: "NewAppointment",
  components: {
      DeleteModal,
      TablePlaceholder
  },
  data() {
    return {
        appointment_list : [],
        search: "",
    }
  },
  mounted() {
    this.$appAxios.get("/Appointments").then(appointment_list_res => {
        this.appointment_list = appointment_list_res.data || []
    })
  },
  methods: {
    deleteAppointment(appointment) {
        this.$appAxios.delete(`/Appointments/${appointment.appointmentId}`).then(delete_response => {
            console.log(delete_response);
            if (delete_response.status == 200){
                this.appointment_list = this.appointment_list.filter(
                    appt => appt.appointmentId != appointment.appointmentId
                )
            }
        })
    }
  },
  computed: {
    filteredList() {
        return this.appointment_list.filter(appt => 
            appt.patientName.toLowerCase().includes(this.search.toLowerCase())
        );
    }
  }
}
</script>