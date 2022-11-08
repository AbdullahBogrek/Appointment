<template>
  <div class="container-fluid">

    <HeaderSection />

    <div class="container mt-5">

      <nav class="mb-5">
        <RouterLink to="/" class="link shadow" active-class="link-active">
          Anasayfa
        </RouterLink>
        <RouterLink to="/new" class="link shadow" active-class="link-active">
          Randevu Ekle
        </RouterLink>
      </nav>

      <section>
        <RouterView></RouterView>
      </section>

    </div>

  </div>
</template>

<script>
import HeaderSection from "./components/HeaderSection.vue"

export default {
  name: "App",
  components: {
    HeaderSection
  }
}

</script>

<style>
.link {
  padding: 15px;
  margin-right: 10px;
  text-decoration: none;
  color: black;
  font-weight: 500;
  border-radius: 5px;
}

.link:hover {
  background-color:  #bfe3b4;
  transition: background-color 0.3s ease-in-out;
  color: black;
}

.link-active {
  background-color:  #bfe3b4;
  color: black;
}
</style>