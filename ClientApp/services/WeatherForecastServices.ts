import Axios from "axios";
import { WeatherForecast } from "../types/WeatherForecast";
import { AxiosResponse } from "axios";

class WeatherForecastServices {
    async retrieveData(city: string): Promise<any> {
        return Axios.get('api/SampleData/WeatherForecasts?ort=Munich').then(res => {
            return res.data;
        })
    }
}

export const weatherForecastServices = new WeatherForecastServices();
