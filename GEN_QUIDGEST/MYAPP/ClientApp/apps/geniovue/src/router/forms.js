import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/FORM_BRAND/:mode/:id?',
			name: 'form-FORM_BRAND',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormBrand/QFormFormBrand.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'BRAND',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_CATEGORY/:mode/:id?',
			name: 'form-FORM_CATEGORY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormCategory/QFormFormCategory.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATEGORY',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_COUNTRY/:mode/:id?',
			name: 'form-FORM_COUNTRY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormCountry/QFormFormCountry.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'COUNTRY',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_INVOICE/:mode/:id?',
			name: 'form-FORM_INVOICE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormInvoice/QFormFormInvoice.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INVOICE',
				humanKeyFields: ['ValCodinvoicestore'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_ITEM/:mode/:id?',
			name: 'form-FORM_ITEM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormItem/QFormFormItem.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValName'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_PERSON/:mode/:id?',
			name: 'form-FORM_PERSON',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormPerson/QFormFormPerson.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PERSON',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_PERSONPSW/:mode/:id?',
			name: 'form-FORM_PERSONPSW',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormPersonpsw/QFormFormPersonpsw.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PERSONPSW',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_PHOTO_ALBUM/:mode/:id?',
			name: 'form-FORM_PHOTO_ALBUM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormPhotoAlbum/QFormFormPhotoAlbum.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PHOTOALBUM',
				humanKeyFields: ['ValTitle'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_STORE/:mode/:id?',
			name: 'form-FORM_STORE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormStore/QFormFormStore.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'STORE',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/FORM_SUBCATEGORY/:mode/:id?',
			name: 'form-FORM_SUBCATEGORY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFormSubcategory/QFormFormSubcategory.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SUBCATEGORY',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/W_FAVSTORES/:mode/:id?',
			name: 'form-W_FAVSTORES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWFavstores/QFormWFavstores.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INVOICE',
				humanKeyFields: ['ValCodinvoicestore'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/W_LASTINVOICE/:mode/:id?',
			name: 'form-W_LASTINVOICE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWLastinvoice/QFormWLastinvoice.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
