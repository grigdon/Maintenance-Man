import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { AddCarModal } from "../components/AddCarModal";
import { Heatmap } from "../components/Heatmap.tsx";
import { Car } from "../types/Car.ts";
import "../pages_css/Home.css";
import "../index.css";
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

  // Function to render either a car tile or a static image
  const renderTile = (index: number) => {
    const car = cars[index];
    
    if (car) {
      return (
        <div
          key={index}
          className="tile"
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
      );
    }
    
    // Default static images
    const images = [
      "image1.jpg",
      "image2.jpg", 
      "image3.jpg", 
      "image4.jpg"
    ];
    
    return (
      <div className="tile" key={`static-${index}`}>
        <img src={images[index]} alt={`Image ${index + 1}`} />
      </div>
    );
  };

  return (
    <div className="index-container">
      {message && <div className="message">{message}</div>}
      
      <button className="btn-add-car" onClick={() => setModalOpen(true)}>
        <img className="car-image" src={plusIcon} alt="Add Car" />
      </button>
      
      {/* Tile Row with Dynamic Car Tiles */}
      <div className="tile-row">
        {[0, 1, 2, 3].map(renderTile)}
      </div>

      {/* Cars Display Section - Now removed as cars are displayed in tile row */}
      <AddCarModal
        isOpen={modalOpen}
        onSubmit={onSubmit}
        onCancel={handleCancel}
        onClose={() => {
          setModalOpen(false);
        }}
      />

      <div className="heatmap-container">
        <Heatmap />
      </div>
    </div>
  );
}

export default Home;