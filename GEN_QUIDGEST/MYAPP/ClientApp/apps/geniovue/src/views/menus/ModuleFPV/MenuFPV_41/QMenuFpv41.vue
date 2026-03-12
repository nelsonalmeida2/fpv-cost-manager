<template>
	<q-dashboard
		v-if="componentOnLoadProc.loaded"
		v-bind="controls.dashboard"
		v-on="controls.dashboard.handlers" />
</template>

<script>
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import DashboardHandlers from '@/mixins/dashboardHandlers.js'
	import { DashboardControl } from '@/mixins/dashboardControl.js'

	const requiredTextResources = ['QMenuFPV_41', 'hardcoded', 'messages']

	export default {
		name: 'QMenuFpv41',

		mixins: [
			GenericMenuHandlers,
			DashboardHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuFPV_41', false),

				interfaceMetadata: {
					id: 'QMenuFPV_41', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'FPV_41',
					name: 'Dashboard',
					route: 'menu-FPV_41',
					order: '41'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'FPV_Menu_41',
						title: computed(() => this.Resources.DASHBOARD51597),
						groups: [
						],
					}, this)
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))
			this.componentOnLoadProc.addImmediateBusy(this.fetchDashboardData(this.controls.dashboard))
			this.componentOnLoadProc.once(() => this.controls.dashboard.init(), this)
		}
	}
</script>
