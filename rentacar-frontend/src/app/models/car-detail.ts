import { Car } from "./car";
import { CarImage } from "./car-image";

export interface CarDetail {
    car: Car;
    imageList: CarImage[]
}