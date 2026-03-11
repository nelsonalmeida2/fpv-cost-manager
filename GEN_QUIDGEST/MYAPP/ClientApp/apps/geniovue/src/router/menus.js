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
			path: '/:culture/:system/FPV/menu/FPV_211',
			name: 'menu-FPV_211',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_211/QMenuFpv211.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '211',
				baseArea: 'INVOICE',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodinvoicestore'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_151',
			name: 'menu-FPV_151',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_151/QMenuFpv151.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '151',
				baseArea: 'COUNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_131',
			name: 'menu-FPV_131',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_131/QMenuFpv131.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '131',
				baseArea: 'CATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_321',
			name: 'menu-FPV_321',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_321/QMenuFpv321.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '321',
				baseArea: 'STORE',
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
		{
			path: '/:culture/:system/FPV/menu/FPV_311',
			name: 'menu-FPV_311',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_311/QMenuFpv311.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '311',
				baseArea: 'BRAND',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_141',
			name: 'menu-FPV_141',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_141/QMenuFpv141.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '141',
				baseArea: 'SUBCATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_221',
			name: 'menu-FPV_221',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_221/QMenuFpv221.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '221',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
