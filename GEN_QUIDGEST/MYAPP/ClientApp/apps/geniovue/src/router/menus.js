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
			path: '/:culture/:system/FPV/menu/FPV_21',
			name: 'menu-FPV_21',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_21/QMenuFpv21.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '21',
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
			path: '/:culture/:system/FPV/menu/FPV_41',
			name: 'menu-FPV_41',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_41/QMenuFpv41.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '41',
				baseArea: 'STORE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_61',
			name: 'menu-FPV_61',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_61/QMenuFpv61.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '61',
				baseArea: 'PHOTOALBUM',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
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
			path: '/:culture/:system/FPV/menu/FPV_51',
			name: 'menu-FPV_51',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_51/QMenuFpv51.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '51',
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
			path: '/:culture/:system/FPV/menu/FPV_31',
			name: 'menu-FPV_31',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_31/QMenuFpv31.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '31',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
