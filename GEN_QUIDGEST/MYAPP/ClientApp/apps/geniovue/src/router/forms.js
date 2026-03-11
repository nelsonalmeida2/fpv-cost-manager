import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
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
