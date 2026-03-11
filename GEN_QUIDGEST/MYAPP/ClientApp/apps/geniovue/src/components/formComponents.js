import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFormPersonpsw', defineAsyncComponent(() => import('@/views/forms/FormFormPersonpsw/QFormFormPersonpsw.vue')))
	}
}
