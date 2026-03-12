<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="FORM_INVOICE"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.FORM_INVOICE__PSEUD__NEWGRP01.isVisible">
					<q-col v-if="controls.FORM_INVOICE__PSEUD__NEWGRP01.isVisible">
						<q-group-collapsible
							v-if="controls.FORM_INVOICE__PSEUD__NEWGRP01.isVisible"
							id="FORM_INVOICE__PSEUD__NEWGRP01"
							v-bind="controls.FORM_INVOICE__PSEUD__NEWGRP01"
							v-on="controls.FORM_INVOICE__PSEUD__NEWGRP01.handlers">
							<!-- Start FORM_INVOICE__PSEUD__NEWGRP01 -->
							<q-row v-if="controls.FORM_INVOICE__INVOICE__CREATED_BY.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__CREATED_BY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__CREATED_BY.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__CREATED_BY"
										v-on="controls.FORM_INVOICE__INVOICE__CREATED_BY.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__CREATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_INVOICE__INVOICE__CREATED_BY.props"
											@blur="onBlur(controls.FORM_INVOICE__INVOICE__CREATED_BY, model.ValCreated_by.value)"
											@change="model.ValCreated_by.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_INVOICE__INVOICE__CREATED_AT.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__CREATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__CREATED_AT.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__CREATED_AT"
										v-on="controls.FORM_INVOICE__INVOICE__CREATED_AT.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__CREATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FORM_INVOICE__INVOICE__CREATED_AT.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__CREATED_AT.props"
											:model-value="model.ValCreated_at.value"
											@reset-icon-click="model.ValCreated_at.fnUpdateValue(model.ValCreated_at.originalValue ?? new Date())"
											@update:model-value="model.ValCreated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_INVOICE__INVOICE__UPDATED_BY.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__UPDATED_BY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__UPDATED_BY.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__UPDATED_BY"
										v-on="controls.FORM_INVOICE__INVOICE__UPDATED_BY.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__UPDATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_INVOICE__INVOICE__UPDATED_BY.props"
											@blur="onBlur(controls.FORM_INVOICE__INVOICE__UPDATED_BY, model.ValUpdated_by.value)"
											@change="model.ValUpdated_by.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_INVOICE__INVOICE__UPDATED_AT.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__UPDATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__UPDATED_AT.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__UPDATED_AT"
										v-on="controls.FORM_INVOICE__INVOICE__UPDATED_AT.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__UPDATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FORM_INVOICE__INVOICE__UPDATED_AT.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__UPDATED_AT.props"
											:model-value="model.ValUpdated_at.value"
											@reset-icon-click="model.ValUpdated_at.fnUpdateValue(model.ValUpdated_at.originalValue ?? new Date())"
											@update:model-value="model.ValUpdated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_INVOICE__PSEUD__NEWGRP01 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_INVOICE__PSEUD__NEWGRP02.isVisible">
					<q-col v-if="controls.FORM_INVOICE__PSEUD__NEWGRP02.isVisible">
						<q-group-box-container
							v-if="controls.FORM_INVOICE__PSEUD__NEWGRP02.isVisible"
							id="FORM_INVOICE__PSEUD__NEWGRP02"
							v-bind="controls.FORM_INVOICE__PSEUD__NEWGRP02"
							:is-visible="controls.FORM_INVOICE__PSEUD__NEWGRP02.isVisible">
							<!-- Start FORM_INVOICE__PSEUD__NEWGRP02 -->
							<q-row v-if="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.isVisible || controls.FORM_INVOICE__INVOICE__RECEIPT.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE"
										v-on="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_INVOICE__INVOICE__CODINVOICESTORE.props"
											@blur="onBlur(controls.FORM_INVOICE__INVOICE__CODINVOICESTORE, model.ValCodinvoicestore.value)"
											@change="model.ValCodinvoicestore.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__RECEIPT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__RECEIPT.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__RECEIPT"
										v-on="controls.FORM_INVOICE__INVOICE__RECEIPT.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__RECEIPT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-document
											v-if="controls.FORM_INVOICE__INVOICE__RECEIPT.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__RECEIPT.props"
											v-on="controls.FORM_INVOICE__INVOICE__RECEIPT.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_INVOICE__STORE__NAME.isVisible || controls.FORM_INVOICE__INVOICE__DATE.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__STORE__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__STORE__NAME.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__STORE__NAME"
										v-on="controls.FORM_INVOICE__STORE__NAME.handlers"
										:loading="controls.FORM_INVOICE__STORE__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FORM_INVOICE__STORE__NAME.isVisible"
											v-bind="controls.FORM_INVOICE__STORE__NAME.props"
											v-on="controls.FORM_INVOICE__STORE__NAME.handlers" />
										<q-see-more-form-invoice-store-name
											v-if="controls.FORM_INVOICE__STORE__NAME.seeMoreIsVisible"
											v-bind="controls.FORM_INVOICE__STORE__NAME.seeMoreParams"
											v-on="controls.FORM_INVOICE__STORE__NAME.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__DATE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__DATE.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__DATE"
										v-on="controls.FORM_INVOICE__INVOICE__DATE.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__DATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FORM_INVOICE__INVOICE__DATE.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__DATE.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_INVOICE__PSEUD__NEWGRP02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_INVOICE__PSEUD__NEWGRP03.isVisible">
					<q-col v-if="controls.FORM_INVOICE__PSEUD__NEWGRP03.isVisible">
						<q-group-box-container
							v-if="controls.FORM_INVOICE__PSEUD__NEWGRP03.isVisible"
							id="FORM_INVOICE__PSEUD__NEWGRP03"
							v-bind="controls.FORM_INVOICE__PSEUD__NEWGRP03"
							:is-visible="controls.FORM_INVOICE__PSEUD__NEWGRP03.isVisible">
							<!-- Start FORM_INVOICE__PSEUD__NEWGRP03 -->
							<q-row v-if="controls.FORM_INVOICE__INVOICE__PRICE.isVisible || controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.isVisible || controls.FORM_INVOICE__INVOICE__TAXES.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__PRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__PRICE.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__PRICE"
										v-on="controls.FORM_INVOICE__INVOICE__PRICE.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__PRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_INVOICE__INVOICE__PRICE.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__PRICE.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST"
										v-on="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__SHIPPINGCOST.props"
											@update:model-value="model.ValShippingcost.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__TAXES.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__TAXES.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__TAXES"
										v-on="controls.FORM_INVOICE__INVOICE__TAXES.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__TAXES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_INVOICE__INVOICE__TAXES.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__TAXES.props"
											@update:model-value="model.ValTaxes.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.isVisible || controls.FORM_INVOICE__INVOICE__TOTALPRICE.isVisible">
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS"
										v-on="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__NUMBEROFITEMS.props"
											@update:model-value="model.ValNumberofitems.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_INVOICE__INVOICE__TOTALPRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_INVOICE__INVOICE__TOTALPRICE.isVisible"
										class="i-text"
										v-bind="controls.FORM_INVOICE__INVOICE__TOTALPRICE"
										v-on="controls.FORM_INVOICE__INVOICE__TOTALPRICE.handlers"
										:loading="controls.FORM_INVOICE__INVOICE__TOTALPRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_INVOICE__INVOICE__TOTALPRICE.isVisible"
											v-bind="controls.FORM_INVOICE__INVOICE__TOTALPRICE.props"
											@update:model-value="model.ValTotalprice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_INVOICE__PSEUD__NEWGRP03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_INVOICE__PSEUD__NEWGRP04.isVisible">
					<q-col v-if="controls.FORM_INVOICE__PSEUD__NEWGRP04.isVisible">
						<q-group-box-container
							v-if="controls.FORM_INVOICE__PSEUD__NEWGRP04.isVisible"
							id="FORM_INVOICE__PSEUD__NEWGRP04"
							v-bind="controls.FORM_INVOICE__PSEUD__NEWGRP04"
							:is-visible="controls.FORM_INVOICE__PSEUD__NEWGRP04.isVisible">
							<!-- Start FORM_INVOICE__PSEUD__NEWGRP04 -->
							<q-row v-if="controls.FORM_INVOICE__PSEUD__FIELD001.isVisible">
								<q-col v-if="controls.FORM_INVOICE__PSEUD__FIELD001.isVisible">
									<q-table
										v-if="controls.FORM_INVOICE__PSEUD__FIELD001.isVisible"
										v-bind="controls.FORM_INVOICE__PSEUD__FIELD001"
										v-on="controls.FORM_INVOICE__PSEUD__FIELD001.handlers">
										<template #header>
											<q-table-config
												:table-ctrl="controls.FORM_INVOICE__PSEUD__FIELD001"
												v-on="controls.FORM_INVOICE__PSEUD__FIELD001.handlers" />
										</template>
										<!-- USE /[MANUAL FPV CUSTOM_TABLE FORM_INVOICE__PSEUD__FIELD001]/ -->
									</q-table>
								</q-col>
							</q-row>
							<!-- End FORM_INVOICE__PSEUD__NEWGRP04 -->
						</q-group-box-container>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormFormInvoiceViewModel.js'

	const requiredTextResources = ['QFormFormInvoice', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FORM_INCLUDEJS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFormInvoice',

		components: {
			QSeeMoreFormInvoiceStoreName: defineAsyncComponent(() => import('@/views/forms/FormFormInvoice/dbedits/FormInvoiceStoreNameSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'FORM_INVOICE',
					location: 'form-FORM_INVOICE',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFormInvoice', false),

				interfaceMetadata: {
					id: 'QFormFormInvoice', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FORM_INVOICE',
					route: 'form-FORM_INVOICE',
					area: 'INVOICE',
					primaryKey: 'ValCodinvoice',
					designation: computed(() => this.Resources.INVOICE63068),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					FORM_INVOICE__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'FORM_INVOICE__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.METADATA52342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['FORM_INVOICE__INVOICE__CREATED_BY', 'FORM_INVOICE__INVOICE__CREATED_AT', 'FORM_INVOICE__INVOICE__UPDATED_BY', 'FORM_INVOICE__INVOICE__UPDATED_AT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__CREATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValCreated_by',
						valueChangeEvent: 'fieldChange:invoice.created_by',
						id: 'FORM_INVOICE__INVOICE__CREATED_BY',
						name: 'CREATED_BY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP01',
						maxLength: 100,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__CREATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValCreated_at',
						valueChangeEvent: 'fieldChange:invoice.created_at',
						id: 'FORM_INVOICE__INVOICE__CREATED_AT',
						name: 'CREATED_AT',
						size: 'xxlarge',
						label: computed(() => this.Resources.CREATED_AT29089),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP01',
						dateTimeType: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__UPDATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValUpdated_by',
						valueChangeEvent: 'fieldChange:invoice.updated_by',
						id: 'FORM_INVOICE__INVOICE__UPDATED_BY',
						name: 'UPDATED_BY',
						size: 'xxlarge',
						label: computed(() => this.Resources.UPDATED_BY17808),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP01',
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__UPDATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValUpdated_at',
						valueChangeEvent: 'fieldChange:invoice.updated_at',
						id: 'FORM_INVOICE__INVOICE__UPDATED_AT',
						name: 'UPDATED_AT',
						size: 'xxlarge',
						label: computed(() => this.Resources.UPDATED_AT48366),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__PSEUD__NEWGRP02: new fieldControlClass.GroupControl({
						id: 'FORM_INVOICE__PSEUD__NEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.PURCHASE_DETAILS40558),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FORM_INVOICE__INVOICE__CODINVOICESTORE', 'FORM_INVOICE__INVOICE__RECEIPT', 'FORM_INVOICE__STORE__NAME', 'FORM_INVOICE__INVOICE__DATE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__CODINVOICESTORE: new fieldControlClass.StringControl({
						modelField: 'ValCodinvoicestore',
						valueChangeEvent: 'fieldChange:invoice.codinvoicestore',
						id: 'FORM_INVOICE__INVOICE__CODINVOICESTORE',
						name: 'CODINVOICESTORE',
						size: 'xxlarge',
						label: computed(() => this.Resources.CODINVOICESTORE44054),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP02',
						maxLength: 50,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__RECEIPT: new fieldControlClass.DocumentControl({
						modelField: 'ValReceipt',
						valueChangeEvent: 'fieldChange:invoice.receipt',
						id: 'FORM_INVOICE__INVOICE__RECEIPT',
						name: 'RECEIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.RECEIPT15218),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP02',
						versioningIsOn: true,
						extensions: [],
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__STORE__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableStoreName',
						valueChangeEvent: 'fieldChange:store.name',
						id: 'FORM_INVOICE__STORE__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.STORE16493),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValStore',
							dependencyEvent: 'fieldChange:invoice.store'
						},
						dependentFields: () => ({
							set 'store.codstore'(value) { vm.model.ValStore.updateValue(value) },
							set 'store.name'(value) { vm.model.TableStoreName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__DATE: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:invoice.date',
						id: 'FORM_INVOICE__INVOICE__DATE',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP02',
						dateTimeType: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__PSEUD__NEWGRP03: new fieldControlClass.GroupControl({
						id: 'FORM_INVOICE__PSEUD__NEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.COST_BREAKDOWN51129),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FORM_INVOICE__INVOICE__PRICE', 'FORM_INVOICE__INVOICE__SHIPPINGCOST', 'FORM_INVOICE__INVOICE__TAXES', 'FORM_INVOICE__INVOICE__NUMBEROFITEMS', 'FORM_INVOICE__INVOICE__TOTALPRICE'],
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__PRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:invoice.price',
						id: 'FORM_INVOICE__INVOICE__PRICE',
						name: 'PRICE',
						size: 'small',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP03',
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__SHIPPINGCOST: new fieldControlClass.CurrencyControl({
						modelField: 'ValShippingcost',
						valueChangeEvent: 'fieldChange:invoice.shippingcost',
						id: 'FORM_INVOICE__INVOICE__SHIPPINGCOST',
						name: 'SHIPPINGCOST',
						size: 'medium',
						label: computed(() => this.Resources.SHIPPING_COST12785),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP03',
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__TAXES: new fieldControlClass.CurrencyControl({
						modelField: 'ValTaxes',
						valueChangeEvent: 'fieldChange:invoice.taxes',
						id: 'FORM_INVOICE__INVOICE__TAXES',
						name: 'TAXES',
						size: 'small',
						label: computed(() => this.Resources.TAXES34617),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP03',
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__NUMBEROFITEMS: new fieldControlClass.NumberControl({
						modelField: 'ValNumberofitems',
						valueChangeEvent: 'fieldChange:invoice.numberofitems',
						id: 'FORM_INVOICE__INVOICE__NUMBEROFITEMS',
						name: 'NUMBEROFITEMS',
						size: 'medium',
						label: computed(() => this.Resources.NUMBER_OF_ITEMS22472),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP03',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__INVOICE__TOTALPRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValTotalprice',
						valueChangeEvent: 'fieldChange:invoice.totalprice',
						id: 'FORM_INVOICE__INVOICE__TOTALPRICE',
						name: 'TOTALPRICE',
						size: 'small',
						label: computed(() => this.Resources.TOTAL_PRICE46894),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP03',
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__PSEUD__NEWGRP04: new fieldControlClass.GroupControl({
						id: 'FORM_INVOICE__PSEUD__NEWGRP04',
						name: 'NEWGRP04',
						size: 'block',
						label: computed(() => this.Resources.ITEMS55321),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FORM_INVOICE__PSEUD__FIELD001'],
						controlLimits: [
						],
					}, this),
					FORM_INVOICE__PSEUD__FIELD001: new fieldControlClass.TableListControl({
						id: 'FORM_INVOICE__PSEUD__FIELD001',
						name: 'FIELD001',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_INVOICE__PSEUD__NEWGRP04',
						controller: 'INVOICE',
						action: 'Form_invoice_ValField001',
						hasDependencies: true,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'ITEM',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 255,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValUnitprice',
								area: 'ITEM',
								field: 'UNITPRICE',
								label: computed(() => this.Resources.UNIT_PRICE24898),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValQuantity',
								area: 'ITEM',
								field: 'QUANTITY',
								label: computed(() => this.Resources.QUANTITY06415),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								name: 'ValTotalprice',
								area: 'ITEM',
								field: 'TOTALPRICE',
								label: computed(() => this.Resources.TOTAL_PRICE46894),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValField001',
							serverMode: true,
							pkColumn: 'ValCoditem',
							tableAlias: 'ITEM',
							tableNamePlural: computed(() => this.Resources.ITEMS55321),
							viewManagement: '',
							showLimitsInfo: true,
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'FORM_ITEM',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'FORM_ITEM',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'FORM_ITEM',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'FORM_ITEM',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'FORM_ITEM',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__FORM_ITEM',
								name: '_FORM_ITEM',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'FORM_ITEM',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'FORM_ITEM': {
									fnKeySelector: (row) => row.Fields.ValCoditem,
									isPopup: true
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CATEGORY', 'changed-ITEM', 'changed-INVOICE', 'changed-SUBCATEGORY', 'changed-BRAND'],
						uuid: 'Form_invoice_ValField001',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'invoice'],
								dependencyEvents: ['fieldChange:invoice.codinvoice'],
								dependencyField: 'INVOICE.CODINVOICE',
								fnValueSelector: (model) => model.ValCodinvoice.value
							},
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'FORM_INVOICE__PSEUD__NEWGRP01',
					'FORM_INVOICE__PSEUD__NEWGRP02',
					'FORM_INVOICE__PSEUD__NEWGRP03',
					'FORM_INVOICE__PSEUD__NEWGRP04',
				]),

				tableFields: readonly([
					'FORM_INVOICE__PSEUD__FIELD001',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Invoice: {
						get ValCodinvoicestore() { return vm.model.ValCodinvoicestore.value },
						set ValCodinvoicestore(value) { vm.model.ValCodinvoicestore.updateValue(value) },
						get ValCodperson() { return vm.model.ValCodperson.value },
						set ValCodperson(value) { vm.model.ValCodperson.updateValue(value) },
						get ValCreated_at() { return vm.model.ValCreated_at.value },
						set ValCreated_at(value) { vm.model.ValCreated_at.updateValue(value) },
						get ValCreated_by() { return vm.model.ValCreated_by.value },
						set ValCreated_by(value) { vm.model.ValCreated_by.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValNumberofitems() { return vm.model.ValNumberofitems.value },
						set ValNumberofitems(value) { vm.model.ValNumberofitems.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValReceipt() { return vm.model.ValReceipt.value },
						set ValReceipt(value) { vm.model.ValReceipt.updateValue(value) },
						get ValShippingcost() { return vm.model.ValShippingcost.value },
						set ValShippingcost(value) { vm.model.ValShippingcost.updateValue(value) },
						get ValStore() { return vm.model.ValStore.value },
						set ValStore(value) { vm.model.ValStore.updateValue(value) },
						get ValTaxes() { return vm.model.ValTaxes.value },
						set ValTaxes(value) { vm.model.ValTaxes.updateValue(value) },
						get ValTotalprice() { return vm.model.ValTotalprice.value },
						set ValTotalprice(value) { vm.model.ValTotalprice.updateValue(value) },
						get ValUpdated_at() { return vm.model.ValUpdated_at.value },
						set ValUpdated_at(value) { vm.model.ValUpdated_at.updateValue(value) },
						get ValUpdated_by() { return vm.model.ValUpdated_by.value },
						set ValUpdated_by(value) { vm.model.ValUpdated_by.updateValue(value) },
					},
					Person: {
						get ValName() { return vm.model.TablePersonName.value },
						set ValName(value) { vm.model.TablePersonName.updateValue(value) },
					},
					Store: {
						get ValName() { return vm.model.TableStoreName.value },
						set ValName(value) { vm.model.TableStoreName.updateValue(value) },
					},
					keys: {
						/** The primary key of the INVOICE table */
						get invoice() { return vm.model.ValCodinvoice },
						/** The foreign key to the STORE table */
						get store() { return vm.model.ValStore },
						/** The foreign key to the PERSON table */
						get person() { return vm.model.ValCodperson },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FORM_CODEJS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV COMPONENT_BEFORE_UNMOUNT FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV BEFORE_LOAD_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FORM_LOADED_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV BEFORE_APPLY_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV AFTER_APPLY_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV BEFORE_SAVE_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV AFTER_SAVE_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV BEFORE_DEL_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV AFTER_DEL_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV BEFORE_EXIT_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV AFTER_EXIT_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV DLGUPDT FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV CTRLBLR FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV CTRLUPD FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FUNCTIONS_JS FORM_INVOICE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
