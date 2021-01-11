<template>
  <div :id="`planetaryHolder_${name}`" class="planetaryHolder">
    <canvas :id="`planet_${name}`"></canvas>
  </div>
</template>

<script>
import * as THREE from 'three'

export default {
  name: 'planet',
  props: {
    name: { type: String, required: false, default: '' },
    texture: { type: String, required: false, default: 'earth' },
    card: { type: Boolean, required: false, default: false },
    isFiction: { type: Boolean, required: false, default: false },
    width: { type: Number, required: false, default: 50 },
    height: { type: Number, required: false, default: 50 },
  },
  data() {
    return {
      sphere: null,
      renderer: null,
      scene: null,
      camera: null,
      map: null,
    }
  },
  computed: {
    isCard() {
      return this.card
        ? 'position: absolute; z-index: 50'
        : 'display: flex; flex-basis: 25%; max-width: 25%'
    },
  },
  mounted() {
    this.init()
    this.animate()
  },
  methods: {
    init() {
      // create scene
      this.scene = new THREE.Scene()
      // create camera
      this.camera = new THREE.PerspectiveCamera(
        45,
        this.width / this.height,
        0.1,
        1000
      )
      this.camera.position.z = 5
      // get container
      const container = document.getElementById(`planetaryHolder_${this.name}`)
      // create light
      // eslint-disable-next-line unicorn/number-literal-case
      const light = new THREE.PointLight(0xff0000, 1, 100)
      light.position.set(50, 50, 50)
      light.castShadow = true
      this.scene.add(light)

      // create renderer
      this.renderer = new THREE.WebGLRenderer({
        canvas: document.getElementById(`planet_${this.name}`),
        alpha: true,
      })
      this.renderer.setSize(this.width, this.height)

      container.appendChild(this.renderer.domElement)

      // create shape
      this.newPlanet(this.name)
    },
    animate() {
      requestAnimationFrame(this.animate)

      this.sphere.rotation.x += 0.01
      this.sphere.rotation.y += 0.01

      this.renderer.render(this.scene, this.camera)
    },
    newPlanet(planet) {
      if (planet === 'saturn') {
        // create the group
        this.sphere = new THREE.Group()
        this.scene.add(this.sphere)
        // create the planet
        const planetGeometry = new THREE.SphereBufferGeometry(1, 50, 50)
        this.map = new THREE.TextureLoader().load(this.texture)
        const planetMaterial = new THREE.MeshBasicMaterial({ map: this.map })
        const planetObject = new THREE.Mesh(planetGeometry, planetMaterial)
        planetObject.castShadow = true
        planetObject.receiveShadow = true
        this.sphere.add(planetObject)
        // create the ring
        const ringGeometry = new THREE.RingGeometry(1.3, 2, 32)
        const ringMaterial = new THREE.MeshBasicMaterial({
          map: new THREE.TextureLoader().load(
            `/images/textures/2k_saturn_ring.png`
          ),
        })
        const ring = new THREE.Mesh(ringGeometry, ringMaterial)
        ring.rotateX(45)
        ring.castShadow = true
        ring.receiveShadow = true
        this.sphere.add(ring)
      } else {
        const geometry = new THREE.SphereBufferGeometry(1, 32, 32)
        this.map = new THREE.TextureLoader().load(this.texture)
        // eslint-disable-next-line unicorn/number-literal-case
        const material = new THREE.MeshBasicMaterial({ map: this.map })
        this.sphere = new THREE.Mesh(geometry, material)
        this.sphere.castShadow = true
        this.sphere.receiveShadow = true
        this.scene.add(this.sphere)
      }
    },
  },
}
</script>

<style scoped lang="scss">
.planetaryHolder {
  display: flex;
  height: 100%;
  align-items: center;
}
</style>
