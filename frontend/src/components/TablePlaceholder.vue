<template>
    <div class="row justify-content-center shadow pb-5">
        <img src="../assets/table_placeholder.png" alt="table placeholder" class="placeholder_img">
        <h5 class="text-center">Herhangi bir randevu kaydı bulunmamaktadır. Randevu eklemek için <RouterLink to="/new">buraya</RouterLink> tıklayabilirsiniz.</h5>
    </div>
</template>

<style>
.placeholder_img {
    width: 60%;
}

@media only screen and (max-width: 600px) {
    .placeholder_img {
        width: 100%;
    }
}
</style>