import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFormBrand', defineAsyncComponent(() => import('@/views/forms/FormFormBrand/QFormFormBrand.vue')))
		app.component('QFormFormCategory', defineAsyncComponent(() => import('@/views/forms/FormFormCategory/QFormFormCategory.vue')))
		app.component('QFormFormCountry', defineAsyncComponent(() => import('@/views/forms/FormFormCountry/QFormFormCountry.vue')))
		app.component('QFormFormInvoice', defineAsyncComponent(() => import('@/views/forms/FormFormInvoice/QFormFormInvoice.vue')))
		app.component('QFormFormItem', defineAsyncComponent(() => import('@/views/forms/FormFormItem/QFormFormItem.vue')))
		app.component('QFormFormPerson', defineAsyncComponent(() => import('@/views/forms/FormFormPerson/QFormFormPerson.vue')))
		app.component('QFormFormPersonpsw', defineAsyncComponent(() => import('@/views/forms/FormFormPersonpsw/QFormFormPersonpsw.vue')))
		app.component('QFormFormPhotoAlbum', defineAsyncComponent(() => import('@/views/forms/FormFormPhotoAlbum/QFormFormPhotoAlbum.vue')))
		app.component('QFormFormStore', defineAsyncComponent(() => import('@/views/forms/FormFormStore/QFormFormStore.vue')))
		app.component('QFormFormSubcategory', defineAsyncComponent(() => import('@/views/forms/FormFormSubcategory/QFormFormSubcategory.vue')))
		app.component('QFormSpendingbycategory', defineAsyncComponent(() => import('@/views/forms/FormSpendingbycategory/QFormSpendingbycategory.vue')))
		app.component('QFormWFavstores', defineAsyncComponent(() => import('@/views/forms/FormWFavstores/QFormWFavstores.vue')))
		app.component('QFormWLastinvoice', defineAsyncComponent(() => import('@/views/forms/FormWLastinvoice/QFormWLastinvoice.vue')))
	}
}
