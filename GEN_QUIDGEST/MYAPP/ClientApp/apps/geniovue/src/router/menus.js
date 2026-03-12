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
			path: '/:culture/:system/FPV/menu/FPV_311',
			name: 'menu-FPV_311',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_311/QMenuFpv311.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '311',
				baseArea: 'PERSON',
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
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_331',
			name: 'menu-FPV_331',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_331/QMenuFpv331.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '331',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_341',
			name: 'menu-FPV_341',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_341/QMenuFpv341.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '341',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_351',
			name: 'menu-FPV_351',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_351/QMenuFpv351.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '351',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
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
				baseArea: 'PERSON',
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
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_71',
			name: 'menu-FPV_71',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_71/QMenuFpv71.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '71',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_81',
			name: 'menu-FPV_81',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_81/QMenuFpv81.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '81',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_91',
			name: 'menu-FPV_91',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_91/QMenuFpv91.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '91',
				baseArea: 'PERSON',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_3111',
			name: 'menu-FPV_3111',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_3111/QMenuFpv3111.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '3111',
				baseArea: 'INVOICE',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodinvoicestore'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_511',
			name: 'menu-FPV_511',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_511/QMenuFpv511.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '511',
				baseArea: 'INVOICE',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodinvoicestore'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_231',
			name: 'menu-FPV_231',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_231/QMenuFpv231.vue'),
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '231',
				baseArea: 'COUNTRY',
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
				baseArea: 'CATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_3311',
			name: 'menu-FPV_3311',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_3311/QMenuFpv3311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '3311',
				baseArea: 'STORE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_711',
			name: 'menu-FPV_711',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_711/QMenuFpv711.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '711',
				baseArea: 'STORE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_3511',
			name: 'menu-FPV_3511',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_3511/QMenuFpv3511.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '3511',
				baseArea: 'PHOTOALBUM',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_911',
			name: 'menu-FPV_911',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_911/QMenuFpv911.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '911',
				baseArea: 'PHOTOALBUM',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['person' /* DB */],
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
			path: '/:culture/:system/FPV/menu/FPV_3411',
			name: 'menu-FPV_3411',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_3411/QMenuFpv3411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '3411',
				baseArea: 'BRAND',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_811',
			name: 'menu-FPV_811',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_811/QMenuFpv811.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '811',
				baseArea: 'BRAND',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
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
				baseArea: 'SUBCATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_3211',
			name: 'menu-FPV_3211',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_3211/QMenuFpv3211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '3211',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/FPV/menu/FPV_611',
			name: 'menu-FPV_611',
			component: () => import('@/views/menus/ModuleFPV/MenuFPV_611/QMenuFpv611.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'FPV',
				order: '611',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['person' /* DB */],
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
				baseArea: 'Dashboard',
				isDashboardPage: true,
				hasInitialPHE: false,
				isPopup: false
			}
		},
	]
}
