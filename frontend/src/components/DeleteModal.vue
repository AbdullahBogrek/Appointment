<template>
    <button type="button" class="service-delete-btn" @click="toggleModal" data-bs-toggle="modal" data-bs-target="#deleteModal">X</button>

    <div v-if="showModal" class="modal fade" tabindex="-1" role="dialog" id="deleteModal">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content rounded-3 shadow">
                <div class="modal-body p-4 text-center">
                    <h5 class="mb-2">Bu servisi silmek istediğine emin misin?</h5>
                    <p class="mb-0">Silinen kayıtlar geri getirilememektedir. Yaptığınız işlemden emin olunuz.</p>
                </div>
                <div class="modal-footer flex-nowrap p-0">
                    <button type="button" class="btn btn-lg btn-delete fs-6 text-decoration-none col-6 m-0 rounded-0" @click="deleteEvent" data-bs-dismiss="modal"><strong>Evet, sil</strong></button>
                    <button type="button" class="btn btn-lg btn-exit fs-6 text-decoration-none col-6 m-0 rounded-0" @click="toggleModal" data-bs-dismiss="modal">İptal</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    emits: ["delete-event"],
    data() {
        return {
            showModal: false
        }
    },
    methods: {
        toggleModal() {
            this.showModal = !this.showModal;
        },
        deleteEvent() {
            this.$emit("delete-event", this.showModal)
            this.toggleModal()
        }
    },
}
</script>

<style>
.btn-delete{
    background-color: #dbb1b4 ;
}
.btn-delete:hover {
    background-color: #e47779 ;
    transition: backgrrgb(245, 125, 127)lor 0.3s ease-in-out;
}
.btn-exit:hover {
    background-color: #D3D3D3 ;
    transition: background-color 0.3s ease-in-out;
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
</style>