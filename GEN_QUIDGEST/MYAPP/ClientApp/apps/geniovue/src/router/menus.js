// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/FPV/menu/FPV_11',
			name: 'menu-FPV_11',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_11/QMenuFpv11.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '11',
				baseArea: 'PERSONPSW',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
