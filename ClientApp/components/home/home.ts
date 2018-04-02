import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { mapGetters } from 'vuex';

@Component({
    computed: mapGetters(['version'])
})
export default class Home extends Vue {
    version: string;
}