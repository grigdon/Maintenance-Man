import { useState } from "react";
import { useNavigate } from "react-router-dom";
<<<<<<< HEAD
import { AddCarModal } from "../components/AddCarModal"; 
import { Car } from "../types/car.ts";
import { Heatmap } from "../components/Heatmap.tsx"; 
import "../pages_css/Home.css";
import "../index.css";
=======

import { Modal } from "../components/Modal";
import { Heatmap } from "../components/Heatmap.tsx";
import { Car } from "../types/Car.ts";

import "../pages_css/Home.css";
import "../index.css";
import "../types/Car.ts";
>>>>>>> 02360ac (Closed #39 - added API service layer to client level)
import plusIcon from "../../src/assets/square-plus-regular.svg";

function Home() {
    const navigate = useNavigate();
    const [modalOpen, setModalOpen] = useState(false);
    const [message, setMessage] = useState("");
    const [cars, setCars] = useState<Car[]>([]);

    const onSubmit = (data: Car) => {
        setCars((prevCars) => [...prevCars, data]);
        setMessage("Car added successfully!");
        setModalOpen(false);
    };

    const handleCancel = (message: string) => {
        setModalOpen(false);
        setMessage(message);
    };

    const handleCarClick = (car: Car) => {
        navigate(`/car/${car.nickname}/maintenance`);
    };

    return (
        <div className="index-container">
            {message && <div className="message">{message}</div>}

            <button className="btn-add-car" onClick={() => setModalOpen(true)}>
                <img className="car-image" src={plusIcon} alt="Add Car" />
            </button>

            {/* Cars Display Section */}
            <div className="cars-grid">
                {cars.map((car, index) => (
                    <div
                        key={index}
                        className="car-card"
                        onClick={() => handleCarClick(car)}
                        style={{ cursor: 'pointer' }}
                    >
                        <h3>{car.nickname}</h3>
                        <div className="car-details">
                            <p><strong>{car.year} {car.make} {car.model}</strong></p>
                            <p>Trim: {car.trim}</p>
                            <p>Engine: {car.engine}</p>
                            <p>Transmission: {car.transmission}</p>
                        </div>
                    </div>
                ))}
            </div>

            <AddCarModal
                isOpen={modalOpen}
                onSubmit={onSubmit}
                onCancel={handleCancel}
                onClose={() => {
                    setModalOpen(false);
                }}
            />

            <div className="tile-row">
                <div className="tile">
                    <img src="image1.jpg" alt="Image 1" />
                </div>
                <div className="tile">
                    <img src="image2.jpg" alt="Image 2" />
                </div>
                <div className="tile">
                    <img src="image3.jpg" alt="Image 3" />
                </div>
                <div className="tile">
                    <img src="image4.jpg" alt="Image 4" />
                </div>
            </div>
            
            <div className="heatmap-container">
                <Heatmap /> 
            </div>
        </div>
    );
}

export default Home;

