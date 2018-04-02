import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        MenuComponent: require('../navmenu/navmenu.vue.html'),
        ToolbarComponent: require('../toolbar/toolbar.vue.html'),
        ToolbarLinkComponent: require('../toolbarlink/toolbarlink.vue.html')
    }
})
export default class AppComponent extends Vue {
}
