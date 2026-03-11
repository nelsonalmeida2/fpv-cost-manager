// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/FPV/menu/FPV_111',
			name: 'menu-FPV_111',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_111/QMenuFpv111.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '111',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_121',
			name: 'menu-FPV_121',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_121/QMenuFpv121.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '121',
				baseArea: 'PERSONPSW',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
