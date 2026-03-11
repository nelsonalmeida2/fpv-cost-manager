import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
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
	]
}
