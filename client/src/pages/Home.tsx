import { useState } from "react";
import { createPortal } from "react-dom";
import { Modal } from "../components/Modal";
import "./Home.css"
import "../index.css"

function Home() {
  const [modalOpen, setModalOpen] = useState(false);
  const [message, setMessage] = useState("");

  const handleButtonClick = (value: string) => {
    setModalOpen(false);
    setMessage(value);
  };

  return (
    <div className="index-container">
      {message}
      <button className="btn-open" onClick={() => setModalOpen(true)}>
        Add_Car_Button
      </button>
      {modalOpen &&
        createPortal(
          <Modal 
            onSubmit={handleButtonClick}
            onCancel={handleButtonClick}
            onClose={handleButtonClick}
          >
            <h1>Form to add a car</h1>
            <p>the form will go here</p>
          </Modal>,
          document.body
        )}
    </div>
  );
}

export default Home;
