<template>
        <div class="container">
            <div class="row d-flex justify-content-center items-center">
                <div class="col-md-5 text-center p-2">
                    <h4 class="mb-5">YENİ RANDEVU</h4>

                    <form class="needs-validation" novalidate>
                        <div class="form-floating mb-4 ">
                            <input type="text" v-model="appointmentData.patientName" class="form-control shadow" id="floatingPatient" placeholder="İsim giriniz." min="5" required>
                            <label for="floatingPatient">Hasta Adı</label>
                            <div class="invalid-feedback">
                                Lütfen hastanın ismini giriniz.
                            </div>
                        </div>

                        <div class="form-floating mb-4">
                            <select v-model="staffName"  class="form-select shadow" id="floatingSelectPersonel" @change="numberToString" aria-label="Floating label select personel" required>
                                <option v-for="staff in staff_list" :key="staff.staffId" v-bind:value="staff.staffId">{{ staff.staffName }}</option>
                            </select>
                            <label for="floatingSelectPersonel">Personel</label>
                            <div class="invalid-feedback">
                                Lütfen bir personel seçiniz.
                            </div>
                        </div>

                        <div class="row g-2 mb-3">
                            <div class="col-md">
                                <div class="form-floating">
                                    <input type="date" v-model="dateOfAppt" class="form-control shadow" @change="convertDatetime" id="floatingInputDate" required>
                                    <label for="floatingInputDate">Randevu Tarihi</label>
                                    <div class="invalid-feedback">
                                        Lütfen randevu tarihi giriniz.
                                    </div>
                                    <div v-if="dataIsFalse" class="invalid-date">
                                        Geçmiş zamana ait bir tarih seçemezsiniz.
                                    </div>
                                </div> 
                            </div>
                            <div class="col-md">
                                <div class="form-floating">
                                    <input type="time" v-model="timeOfAppt" class="form-control shadow" @change="convertDatetime" id="floatingInputTime" required>
                                    <label for="floatingInputTime">Randevu Saati</label>
                                    <div class="invalid-feedback">
                                        Lütfen randevu saatini giriniz.
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-floating mb-4">
                            <select v-model="appointmentData.services" class="form-select shadow" @change="setSelectedServices" id="floatingSelectServices" aria-label="Floating label select services" required>
                                <option v-for="service in service_list" :key="service.serviceName" v-bind:value="(service.serviceId).toString()">{{ service.serviceName }}</option>
                            </select>
                            <label for="floatingSelectServices">Servisler</label>
                            <div class="invalid-feedback">
                                Lütfen en az bir tane servis seçiniz.
                            </div>
                        </div>

                        <div class="services-area">
                            <div v-for="(selectedService, index) in selectedServiceList" :key="selectedService.serviceId" class="d-flex justify-content-start align-items-center shadow p-2">
                                <div class="col-1">
                                    {{ index + 1 }}
                                </div>
                                <div class="col-10 text-start">
                                    {{ selectedService.serviceName }}
                                </div>
                                <div class="col-1 text-end">
                                    <DeleteModal @delete-event="deleteSelectedService(selectedService)" />
                                </div>
                            </div>
                        </div>

                        <div class="mt-5">
                            <button class="save-button shadow" @click="onSave">Kaydet</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
</template>

<script>
import DeleteModal from "../components/DeleteModal.vue"

export default {
  name: "NewAppointment",
  components: {
    DeleteModal
  },
  data() {
    return {
        dataIsFalse: false,
        dateOfAppt: "",
        timeOfAppt: "",
        staffName: "",
        appointmentData: {
            patientName: null,
            staffId: null,
            appointmentDate: null,
            services: null,
        },
        staff_list: [],
        service_list: [],
        selectedServiceList: [],
    }
  },
   methods: {
        convertDatetime() {
            let date = new Date().toISOString().split("T")[0]
            console.log(this.dateOfAppt > date)

            if(this.dateOfAppt < date) {
                this.dataIsFalse = true;
                this.dateOfAppt = "";
            } else {
                this.dataIsFalse = false;
                let date = this.dateOfAppt.concat("T", this.timeOfAppt) + ":00.000Z";
                this.appointmentData.appointmentDate = date;
            }

            console.log(this.dateOfAppt)
        },
        numberToString() {
            this.appointmentData.staffId = parseInt(this.staffName)
        },
        onSave() {
            const isEmpty = Object.values(this.appointmentData).some(appt => appt === null || appt === '');
            if (isEmpty)
                return console.log("Randevu bilgileri olmadan kayıt işlemi yapılamaz.")
            else{
                console.log(this.appointmentData);
                this.$appAxios.post("/Appointments", this.appointmentData).then(save_response => {
                    console.log("save_response", save_response);
                    this.resetData();
                    this.$router.push("/");
                });
            }
        },
        resetData() {
            Object.keys(this.appointmentData).forEach(key =>(
                this.appointmentData[key] = null
            ))
        },
        setSelectedServices(e) {
            const selectedService = this.service_list[e.target.value -1];
            
            let index = this.selectedServiceList.findIndex(x => x.serviceId == selectedService.serviceId);

            index === -1 ? this.selectedServiceList.push(selectedService) : alert("Bu servis zaten seçilidir.")
        },
        deleteSelectedService(select) {
            this.selectedServiceList = this.selectedServiceList.filter(
                x => x.serviceId != select.serviceId
            )
        },
   },
   mounted() {
        this.$appAxios.get("/Staffs").then(staff_list_res => {
            this.staff_list = staff_list_res.data || []
        })

        this.$appAxios.get("/Services").then(service_list_res => {
            this.service_list = service_list_res.data || []
        })

        const forms = document.querySelectorAll('.needs-validation')

        Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
        })
   }
}
</script>

<style>
.services-area{
    padding-left: 50px;
}
.service-delete-btn {
    border: none;
    background-color: #fc8c8e;
    width: 35px;
    height: 35px;
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 4px;
}
.service-delete-btn:hover {
    background-color: #ff6466;
    transition: background-color 0.3s ease-in-out;
}
.save-button {
  background-color:  #a0cc92;
  padding: 10px 60px;
  border: none;
  border-radius: 6px;
}
.save-button:hover {
  background-color:  #7bad6c;
  transition: background-color 0.3s ease-in-out;
}
.invalid-date {
  color: #e45454;
  font-size: 13px;
  margin-top: 2px;
  padding: 2px;
}
</style>