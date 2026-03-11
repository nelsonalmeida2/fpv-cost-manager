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
			data-key="FORM_ITEM"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.FORM_ITEM__PSEUD__NEWGRP01.isVisible">
					<q-col v-if="controls.FORM_ITEM__PSEUD__NEWGRP01.isVisible">
						<q-group-collapsible
							v-if="controls.FORM_ITEM__PSEUD__NEWGRP01.isVisible"
							id="FORM_ITEM__PSEUD__NEWGRP01"
							v-bind="controls.FORM_ITEM__PSEUD__NEWGRP01"
							v-on="controls.FORM_ITEM__PSEUD__NEWGRP01.handlers">
							<!-- Start FORM_ITEM__PSEUD__NEWGRP01 -->
							<q-row v-if="controls.FORM_ITEM__ITEM__CREATED_BY.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__CREATED_BY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__CREATED_BY.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__CREATED_BY"
										v-on="controls.FORM_ITEM__ITEM__CREATED_BY.handlers"
										:loading="controls.FORM_ITEM__ITEM__CREATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_ITEM__ITEM__CREATED_BY.props"
											@blur="onBlur(controls.FORM_ITEM__ITEM__CREATED_BY, model.ValCreated_by.value)"
											@change="model.ValCreated_by.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_ITEM__ITEM__CREATED_AT.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__CREATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__CREATED_AT.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__CREATED_AT"
										v-on="controls.FORM_ITEM__ITEM__CREATED_AT.handlers"
										:loading="controls.FORM_ITEM__ITEM__CREATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FORM_ITEM__ITEM__CREATED_AT.isVisible"
											v-bind="controls.FORM_ITEM__ITEM__CREATED_AT.props"
											:model-value="model.ValCreated_at.value"
											@reset-icon-click="model.ValCreated_at.fnUpdateValue(model.ValCreated_at.originalValue ?? new Date())"
											@update:model-value="model.ValCreated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_ITEM__ITEM__UPDATED_BY.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__UPDATED_BY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__UPDATED_BY.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__UPDATED_BY"
										v-on="controls.FORM_ITEM__ITEM__UPDATED_BY.handlers"
										:loading="controls.FORM_ITEM__ITEM__UPDATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_ITEM__ITEM__UPDATED_BY.props"
											@blur="onBlur(controls.FORM_ITEM__ITEM__UPDATED_BY, model.ValUpdated_by.value)"
											@change="model.ValUpdated_by.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_ITEM__ITEM__UPDATED_AT.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__UPDATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__UPDATED_AT.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__UPDATED_AT"
										v-on="controls.FORM_ITEM__ITEM__UPDATED_AT.handlers"
										:loading="controls.FORM_ITEM__ITEM__UPDATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FORM_ITEM__ITEM__UPDATED_AT.isVisible"
											v-bind="controls.FORM_ITEM__ITEM__UPDATED_AT.props"
											:model-value="model.ValUpdated_at.value"
											@reset-icon-click="model.ValUpdated_at.fnUpdateValue(model.ValUpdated_at.originalValue ?? new Date())"
											@update:model-value="model.ValUpdated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_ITEM__PSEUD__NEWGRP01 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_ITEM__PSEUD__NEWGRP03.isVisible">
					<q-col v-if="controls.FORM_ITEM__PSEUD__NEWGRP03.isVisible">
						<q-group-box-container
							v-if="controls.FORM_ITEM__PSEUD__NEWGRP03.isVisible"
							id="FORM_ITEM__PSEUD__NEWGRP03"
							v-bind="controls.FORM_ITEM__PSEUD__NEWGRP03"
							:is-visible="controls.FORM_ITEM__PSEUD__NEWGRP03.isVisible">
							<!-- Start FORM_ITEM__PSEUD__NEWGRP03 -->
							<q-row v-if="controls.FORM_ITEM__ITEM__NAME.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__NAME.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__NAME"
										v-on="controls.FORM_ITEM__ITEM__NAME.handlers"
										:loading="controls.FORM_ITEM__ITEM__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FORM_ITEM__ITEM__NAME.props"
											@blur="onBlur(controls.FORM_ITEM__ITEM__NAME, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FORM_ITEM__ITEM__QUANTITY.isVisible || controls.FORM_ITEM__ITEM__UNITPRICE.isVisible || controls.FORM_ITEM__ITEM__TOTALPRICE.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__ITEM__QUANTITY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__QUANTITY.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__QUANTITY"
										v-on="controls.FORM_ITEM__ITEM__QUANTITY.handlers"
										:loading="controls.FORM_ITEM__ITEM__QUANTITY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_ITEM__ITEM__QUANTITY.isVisible"
											v-bind="controls.FORM_ITEM__ITEM__QUANTITY.props"
											@update:model-value="model.ValQuantity.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_ITEM__ITEM__UNITPRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__UNITPRICE.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__UNITPRICE"
										v-on="controls.FORM_ITEM__ITEM__UNITPRICE.handlers"
										:loading="controls.FORM_ITEM__ITEM__UNITPRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_ITEM__ITEM__UNITPRICE.isVisible"
											v-bind="controls.FORM_ITEM__ITEM__UNITPRICE.props"
											@update:model-value="model.ValUnitprice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_ITEM__ITEM__TOTALPRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__ITEM__TOTALPRICE.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__ITEM__TOTALPRICE"
										v-on="controls.FORM_ITEM__ITEM__TOTALPRICE.handlers"
										:loading="controls.FORM_ITEM__ITEM__TOTALPRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FORM_ITEM__ITEM__TOTALPRICE.isVisible"
											v-bind="controls.FORM_ITEM__ITEM__TOTALPRICE.props"
											@update:model-value="model.ValTotalprice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_ITEM__PSEUD__NEWGRP03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_ITEM__PSEUD__NEWGRP02.isVisible">
					<q-col v-if="controls.FORM_ITEM__PSEUD__NEWGRP02.isVisible">
						<q-group-box-container
							v-if="controls.FORM_ITEM__PSEUD__NEWGRP02.isVisible"
							id="FORM_ITEM__PSEUD__NEWGRP02"
							v-bind="controls.FORM_ITEM__PSEUD__NEWGRP02"
							:is-visible="controls.FORM_ITEM__PSEUD__NEWGRP02.isVisible">
							<!-- Start FORM_ITEM__PSEUD__NEWGRP02 -->
							<q-row v-if="controls.FORM_ITEM__BRAND__NAME.isVisible || controls.FORM_ITEM__CATEGORY__NAME.isVisible || controls.FORM_ITEM__SUBCATEGORY__NAME.isVisible || controls.FORM_ITEM__INVOICE__CODINVOICESTORE.isVisible">
								<q-col
									v-if="controls.FORM_ITEM__BRAND__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__BRAND__NAME.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__BRAND__NAME"
										v-on="controls.FORM_ITEM__BRAND__NAME.handlers"
										:loading="controls.FORM_ITEM__BRAND__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FORM_ITEM__BRAND__NAME.isVisible"
											v-bind="controls.FORM_ITEM__BRAND__NAME.props"
											v-on="controls.FORM_ITEM__BRAND__NAME.handlers" />
										<q-see-more-form-item-brand-name
											v-if="controls.FORM_ITEM__BRAND__NAME.seeMoreIsVisible"
											v-bind="controls.FORM_ITEM__BRAND__NAME.seeMoreParams"
											v-on="controls.FORM_ITEM__BRAND__NAME.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_ITEM__CATEGORY__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__CATEGORY__NAME.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__CATEGORY__NAME"
										v-on="controls.FORM_ITEM__CATEGORY__NAME.handlers"
										:loading="controls.FORM_ITEM__CATEGORY__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FORM_ITEM__CATEGORY__NAME.isVisible"
											v-bind="controls.FORM_ITEM__CATEGORY__NAME.props"
											v-on="controls.FORM_ITEM__CATEGORY__NAME.handlers" />
										<q-see-more-form-item-category-name
											v-if="controls.FORM_ITEM__CATEGORY__NAME.seeMoreIsVisible"
											v-bind="controls.FORM_ITEM__CATEGORY__NAME.seeMoreParams"
											v-on="controls.FORM_ITEM__CATEGORY__NAME.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_ITEM__SUBCATEGORY__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__SUBCATEGORY__NAME.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__SUBCATEGORY__NAME"
										v-on="controls.FORM_ITEM__SUBCATEGORY__NAME.handlers"
										:loading="controls.FORM_ITEM__SUBCATEGORY__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FORM_ITEM__SUBCATEGORY__NAME.isVisible"
											v-bind="controls.FORM_ITEM__SUBCATEGORY__NAME.props"
											v-on="controls.FORM_ITEM__SUBCATEGORY__NAME.handlers" />
										<q-see-more-form-item-subcategory-name
											v-if="controls.FORM_ITEM__SUBCATEGORY__NAME.seeMoreIsVisible"
											v-bind="controls.FORM_ITEM__SUBCATEGORY__NAME.seeMoreParams"
											v-on="controls.FORM_ITEM__SUBCATEGORY__NAME.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.isVisible"
										class="i-text"
										v-bind="controls.FORM_ITEM__INVOICE__CODINVOICESTORE"
										v-on="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.handlers"
										:loading="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.isVisible"
											v-bind="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.props"
											v-on="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.handlers" />
										<q-see-more-form-item-invoice-codinvoicestore
											v-if="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.seeMoreIsVisible"
											v-bind="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.seeMoreParams"
											v-on="controls.FORM_ITEM__INVOICE__CODINVOICESTORE.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FORM_ITEM__PSEUD__NEWGRP02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FORM_ITEM__PSEUD__FIELD001.isVisible">
					<q-col v-if="controls.FORM_ITEM__PSEUD__FIELD001.isVisible">
						<q-table
							v-if="controls.FORM_ITEM__PSEUD__FIELD001.isVisible"
							v-bind="controls.FORM_ITEM__PSEUD__FIELD001"
							v-on="controls.FORM_ITEM__PSEUD__FIELD001.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.FORM_ITEM__PSEUD__FIELD001"
									v-on="controls.FORM_ITEM__PSEUD__FIELD001.handlers" />
							</template>
							<!-- USE /[MANUAL FPV CUSTOM_TABLE FORM_ITEM__PSEUD__FIELD001]/ -->
						</q-table>
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

	import FormViewModel from './QFormFormItemViewModel.js'

	const requiredTextResources = ['QFormFormItem', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FORM_INCLUDEJS FORM_ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFormItem',

		components: {
			QSeeMoreFormItemBrandName: defineAsyncComponent(() => import('@/views/forms/FormFormItem/dbedits/FormItemBrandNameSeeMore.vue')),
			QSeeMoreFormItemCategoryName: defineAsyncComponent(() => import('@/views/forms/FormFormItem/dbedits/FormItemCategoryNameSeeMore.vue')),
			QSeeMoreFormItemSubcategoryName: defineAsyncComponent(() => import('@/views/forms/FormFormItem/dbedits/FormItemSubcategoryNameSeeMore.vue')),
			QSeeMoreFormItemInvoiceCodinvoicestore: defineAsyncComponent(() => import('@/views/forms/FormFormItem/dbedits/FormItemInvoiceCodinvoicestoreSeeMore.vue')),
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
					name: 'FORM_ITEM',
					location: 'form-FORM_ITEM',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFormItem', false),

				interfaceMetadata: {
					id: 'QFormFormItem', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FORM_ITEM',
					route: 'form-FORM_ITEM',
					area: 'ITEM',
					primaryKey: 'ValCoditem',
					designation: computed(() => this.Resources.ITEM40802),
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
					FORM_ITEM__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'FORM_ITEM__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.METADATA52342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['FORM_ITEM__ITEM__CREATED_BY', 'FORM_ITEM__ITEM__CREATED_AT', 'FORM_ITEM__ITEM__UPDATED_BY', 'FORM_ITEM__ITEM__UPDATED_AT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__CREATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValCreated_by',
						valueChangeEvent: 'fieldChange:item.created_by',
						id: 'FORM_ITEM__ITEM__CREATED_BY',
						name: 'CREATED_BY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP01',
						maxLength: 100,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__CREATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValCreated_at',
						valueChangeEvent: 'fieldChange:item.created_at',
						id: 'FORM_ITEM__ITEM__CREATED_AT',
						name: 'CREATED_AT',
						size: 'xxlarge',
						label: computed(() => this.Resources.CREATED_AT29089),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP01',
						dateTimeType: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__UPDATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValUpdated_by',
						valueChangeEvent: 'fieldChange:item.updated_by',
						id: 'FORM_ITEM__ITEM__UPDATED_BY',
						name: 'UPDATED_BY',
						size: 'xxlarge',
						label: computed(() => this.Resources.UPDATED_BY17808),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP01',
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__UPDATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValUpdated_at',
						valueChangeEvent: 'fieldChange:item.updated_at',
						id: 'FORM_ITEM__ITEM__UPDATED_AT',
						name: 'UPDATED_AT',
						size: 'xxlarge',
						label: computed(() => this.Resources.UPDATED_AT48366),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FORM_ITEM__PSEUD__NEWGRP03: new fieldControlClass.GroupControl({
						id: 'FORM_ITEM__PSEUD__NEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.ITEM_INFO03102),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FORM_ITEM__ITEM__NAME', 'FORM_ITEM__ITEM__QUANTITY', 'FORM_ITEM__ITEM__UNITPRICE', 'FORM_ITEM__ITEM__TOTALPRICE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__NAME: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:item.name',
						id: 'FORM_ITEM__ITEM__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP03',
						maxLength: 255,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__QUANTITY: new fieldControlClass.NumberControl({
						modelField: 'ValQuantity',
						valueChangeEvent: 'fieldChange:item.quantity',
						id: 'FORM_ITEM__ITEM__QUANTITY',
						name: 'QUANTITY',
						size: 'small',
						label: computed(() => this.Resources.QUANTITY06415),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP03',
						maxIntegers: 10,
						maxDecimals: 0,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__UNITPRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValUnitprice',
						valueChangeEvent: 'fieldChange:item.unitprice',
						id: 'FORM_ITEM__ITEM__UNITPRICE',
						name: 'UNITPRICE',
						size: 'small',
						label: computed(() => this.Resources.UNIT_PRICE24898),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP03',
						maxIntegers: 7,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__ITEM__TOTALPRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValTotalprice',
						valueChangeEvent: 'fieldChange:item.totalprice',
						id: 'FORM_ITEM__ITEM__TOTALPRICE',
						name: 'TOTALPRICE',
						size: 'small',
						label: computed(() => this.Resources.TOTAL_PRICE46894),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP03',
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__PSEUD__NEWGRP02: new fieldControlClass.GroupControl({
						id: 'FORM_ITEM__PSEUD__NEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.CATALOG_DETAILS56370),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FORM_ITEM__BRAND__NAME', 'FORM_ITEM__CATEGORY__NAME', 'FORM_ITEM__SUBCATEGORY__NAME', 'FORM_ITEM__INVOICE__CODINVOICESTORE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__BRAND__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableBrandName',
						valueChangeEvent: 'fieldChange:brand.name',
						id: 'FORM_ITEM__BRAND__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.BRAND05002),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValBrand',
							dependencyEvent: 'fieldChange:item.brand'
						},
						dependentFields: () => ({
							set 'brand.codbrand'(value) { vm.model.ValBrand.updateValue(value) },
							set 'brand.name'(value) { vm.model.TableBrandName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__CATEGORY__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableCategoryName',
						valueChangeEvent: 'fieldChange:category.name',
						id: 'FORM_ITEM__CATEGORY__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCategory',
							dependencyEvent: 'fieldChange:item.category'
						},
						dependentFields: () => ({
							set 'category.codcategory'(value) { vm.model.ValCategory.updateValue(value) },
							set 'category.name'(value) { vm.model.TableCategoryName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__SUBCATEGORY__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableSubcategoryName',
						valueChangeEvent: 'fieldChange:subcategory.name',
						id: 'FORM_ITEM__SUBCATEGORY__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.SUB_CATEGORY39956),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValSubcategory',
							dependencyEvent: 'fieldChange:item.subcategory'
						},
						dependentFields: () => ({
							set 'subcategory.codsubcategory'(value) { vm.model.ValSubcategory.updateValue(value) },
							set 'subcategory.name'(value) { vm.model.TableSubcategoryName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
							{
								identifier: ['category', 'item.category'],
								dependencyEvents: ['fieldChange:item.category'],
								dependencyField: 'ITEM.CATEGORY',
								fnValueSelector: (model) => model.ValCategory.value
							},
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyG([ITEM->CATEGORY])
								return !(this.ValCategory.value === '')
							},
							dependencyEvents: ['fieldChange:item.category'],
							isServerRecalc: false,
						},
					}, this),
					FORM_ITEM__INVOICE__CODINVOICESTORE: new fieldControlClass.LookupControl({
						modelField: 'TableInvoiceCodinvoicestore',
						valueChangeEvent: 'fieldChange:invoice.codinvoicestore',
						id: 'FORM_ITEM__INVOICE__CODINVOICESTORE',
						name: 'CODINVOICESTORE',
						size: 'xxlarge',
						label: computed(() => this.Resources.INVOICE63068),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FORM_ITEM__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValInvoice',
							dependencyEvent: 'fieldChange:item.invoice'
						},
						dependentFields: () => ({
							set 'invoice.codinvoice'(value) { vm.model.ValInvoice.updateValue(value) },
							set 'invoice.codinvoicestore'(value) { vm.model.TableInvoiceCodinvoicestore.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					FORM_ITEM__PSEUD__FIELD001: new fieldControlClass.TableListControl({
						id: 'FORM_ITEM__PSEUD__FIELD001',
						name: 'FIELD001',
						size: 'block',
						label: computed(() => this.Resources.NEW_DATA_GRID00674),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'ITEM',
						action: 'Form_item_ValField001',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
						],
						config: {
							name: 'ValField001',
							serverMode: true,
							pkColumn: 'ValCodphotoalbum',
							tableAlias: 'PHOTOALBUM',
							tableNamePlural: computed(() => this.Resources.PHOTOALBUM01892),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.NEW_DATA_GRID00674),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						uuid: 'Form_item_ValField001',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'item'],
								dependencyEvents: ['fieldChange:item.coditem'],
								dependencyField: 'ITEM.CODITEM',
								fnValueSelector: (model) => model.ValCoditem.value
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
					'FORM_ITEM__PSEUD__NEWGRP01',
					'FORM_ITEM__PSEUD__NEWGRP03',
					'FORM_ITEM__PSEUD__NEWGRP02',
				]),

				tableFields: readonly([
					'FORM_ITEM__PSEUD__FIELD001',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Brand: {
						get ValName() { return vm.model.TableBrandName.value },
						set ValName(value) { vm.model.TableBrandName.updateValue(value) },
					},
					Category: {
						get ValName() { return vm.model.TableCategoryName.value },
						set ValName(value) { vm.model.TableCategoryName.updateValue(value) },
					},
					Invoice: {
						get ValCodinvoicestore() { return vm.model.TableInvoiceCodinvoicestore.value },
						set ValCodinvoicestore(value) { vm.model.TableInvoiceCodinvoicestore.updateValue(value) },
					},
					Item: {
						get ValBrand() { return vm.model.ValBrand.value },
						set ValBrand(value) { vm.model.ValBrand.updateValue(value) },
						get ValCategory() { return vm.model.ValCategory.value },
						set ValCategory(value) { vm.model.ValCategory.updateValue(value) },
						get ValCreated_at() { return vm.model.ValCreated_at.value },
						set ValCreated_at(value) { vm.model.ValCreated_at.updateValue(value) },
						get ValCreated_by() { return vm.model.ValCreated_by.value },
						set ValCreated_by(value) { vm.model.ValCreated_by.updateValue(value) },
						get ValInvoice() { return vm.model.ValInvoice.value },
						set ValInvoice(value) { vm.model.ValInvoice.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValQuantity() { return vm.model.ValQuantity.value },
						set ValQuantity(value) { vm.model.ValQuantity.updateValue(value) },
						get ValSubcategory() { return vm.model.ValSubcategory.value },
						set ValSubcategory(value) { vm.model.ValSubcategory.updateValue(value) },
						get ValTotalprice() { return vm.model.ValTotalprice.value },
						set ValTotalprice(value) { vm.model.ValTotalprice.updateValue(value) },
						get ValUnitprice() { return vm.model.ValUnitprice.value },
						set ValUnitprice(value) { vm.model.ValUnitprice.updateValue(value) },
						get ValUpdated_at() { return vm.model.ValUpdated_at.value },
						set ValUpdated_at(value) { vm.model.ValUpdated_at.updateValue(value) },
						get ValUpdated_by() { return vm.model.ValUpdated_by.value },
						set ValUpdated_by(value) { vm.model.ValUpdated_by.updateValue(value) },
					},
					Subcategory: {
						get ValName() { return vm.model.TableSubcategoryName.value },
						set ValName(value) { vm.model.TableSubcategoryName.updateValue(value) },
					},
					keys: {
						/** The primary key of the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the BRAND table */
						get brand() { return vm.model.ValBrand },
						/** The foreign key to the CATEGORY table */
						get category() { return vm.model.ValCategory },
						/** The foreign key to the SUBCATEGORY table */
						get subcategory() { return vm.model.ValSubcategory },
						/** The foreign key to the INVOICE table */
						get invoice() { return vm.model.ValInvoice },
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
// USE /[MANUAL FPV FORM_CODEJS FORM_ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV COMPONENT_BEFORE_UNMOUNT FORM_ITEM]/
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
// USE /[MANUAL FPV BEFORE_LOAD_JS FORM_ITEM]/
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
// USE /[MANUAL FPV FORM_LOADED_JS FORM_ITEM]/
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
// USE /[MANUAL FPV BEFORE_APPLY_JS FORM_ITEM]/
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
// USE /[MANUAL FPV AFTER_APPLY_JS FORM_ITEM]/
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
// USE /[MANUAL FPV BEFORE_SAVE_JS FORM_ITEM]/
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
// USE /[MANUAL FPV AFTER_SAVE_JS FORM_ITEM]/
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
// USE /[MANUAL FPV BEFORE_DEL_JS FORM_ITEM]/
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
// USE /[MANUAL FPV AFTER_DEL_JS FORM_ITEM]/
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
// USE /[MANUAL FPV BEFORE_EXIT_JS FORM_ITEM]/
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
// USE /[MANUAL FPV AFTER_EXIT_JS FORM_ITEM]/
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
// USE /[MANUAL FPV DLGUPDT FORM_ITEM]/
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
// USE /[MANUAL FPV CTRLBLR FORM_ITEM]/
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
// USE /[MANUAL FPV CTRLUPD FORM_ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL FPV FUNCTIONS_JS FORM_ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
