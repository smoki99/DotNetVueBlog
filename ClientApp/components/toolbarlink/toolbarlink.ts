import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component
export default class Toolbarlinks extends Vue {
    @Prop({default: 'Linktext'}) linktext: string;
    @Prop({default: 'Linkpath'}) linkpath: string;

}