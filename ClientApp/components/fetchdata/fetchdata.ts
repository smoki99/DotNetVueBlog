import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { WeatherForecast } from "../../types/WeatherForecast";
import { weatherForecastServices } from '../../services/WeatherForecastServices';
import { mapActions, mapGetters } from 'vuex';


@Component({
    computed: mapGetters(['forecasts']),
    methods: mapActions({fetchWeatherForecast: 'fetchWeatherForecast'})
  })
export default class FetchDataComponent extends Vue {
    fetchWeatherForecast?(): Promise<any>;
    forecasts: WeatherForecast[];

    mounted() {
        if (this.fetchWeatherForecast) {
            this.fetchWeatherForecast();
        }
        if (this.forecasts == null) {
            this.forecasts = [];
        }
    }
}
