import Vue from 'vue';
import Vuex, { StoreOptions, Dispatch } from 'vuex';
import { RootState } from '../types/RootState';
import { WeatherForecast } from "../types/WeatherForecast";
import { weatherForecastServices } from '../services/WeatherForecastServices';

Vue.use(Vuex);

const storevalue: StoreOptions<RootState> = {
    state: {
        version: '2.0.0',
        forecasts: []
    },
    getters: {
        version: state => state.version,
        forecasts: state => {
            return state.forecasts;
        }
    },
    // Mur Mutatins können Daten ändern
    mutations: {
        UPDATE_WEATHER_FORECAST(state, data) {
            state.forecasts = data;
        }
    },
    // Nur Actions können asyncron sein
    actions: {
        fetchWeatherForecast(context) {
            if (context.state.forecasts === null || context.state.forecasts.length == 0) {
                weatherForecastServices.retrieveData("Munich").then(result => {
                    context.commit('UPDATE_WEATHER_FORECAST', result);
                })
            }
        }       
    }
}

const store = new Vuex.Store<RootState>(storevalue)

export default store;
