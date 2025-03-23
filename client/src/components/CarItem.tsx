import { Car } from "../types/car"

interface CarItemProps {
    car: Car;
}

export default function CarItem({car}: CarItemProps) {
    return(
        <div>
            <label>
                {car.nickname}
            </label>
        </div>
    )
}