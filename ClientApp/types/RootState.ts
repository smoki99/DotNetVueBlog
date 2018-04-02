import { WeatherForecast } from "./WeatherForecast";

export interface RootState {
    version: string;
    forecasts: WeatherForecast[];
}