import { useState } from "react";
import { createPortal } from "react-dom";
import { useForm, SubmitHandler } from "react-hook-form";
import { Modal } from "../components/Modal";
import { useParams } from "react-router-dom";
import { Maintenance } from "../types/maintenance.ts";
import "../pages_css/CarProfile.css";

export function CarProfile() {
    const { nickname } = useParams<{ nickname: string }>(); 
    const [modalOpen, setModalOpen] = useState(false);
    const [message, setMessage] = useState("");
    const [maintenanceItems, setMaintenanceItems] = useState<Maintenance[]>([]);
    const { register, handleSubmit, reset, formState: { errors } } = useForm<Maintenance>();

    const onSubmit: SubmitHandler<Maintenance> = (data) => {
        setMaintenanceItems(prevItems => [...prevItems, data]);
        setMessage("Maintenance item added!");
        setModalOpen(false);
        reset();
    };

    const handleCancel = (message: string) => {
        setModalOpen(false);
        setMessage(message);
        reset();
    };

    return (
        <div className="index-container"> {/* Background set to default */}
            {message && <div className="message">{message}</div>}

            {/* Add Maintenance Item button */}
            <button className="btn-add-car" onClick={() => setModalOpen(true)}>
                Add Maintenance Item
            </button>
            

            {/* Modal for adding maintenance item */}
            {modalOpen &&
                createPortal(
                    <Modal
                        onSubmit={() => handleSubmit(onSubmit)()} 
                        onCancel={handleCancel}
                        onClose={() => {
                            setModalOpen(false);
                            reset();
                        }}
                    >
                        <div className="form-container">
                            <h2>Add Maintenance Item</h2>
                            <form onSubmit={handleSubmit(onSubmit)} className="maintenance-form">
                                <div className="form-group">
                                    <label htmlFor="date">Date</label>
                                    <input
                                        id="date"
                                        type="date"
                                        {...register("date", { required: "Date is required" })}
                                        className="form-input"
                                    />
                                    {errors.date && <span className="error">{errors.date.message}</span>}
                                </div>

                                <div className="form-group">
                                    <label htmlFor="description">Description</label>
                                    <input
                                        id="description"
                                        {...register("description", { required: "Description is required" })}
                                        className="form-input"
                                    />
                                    {errors.description && <span className="error">{errors.description.message}</span>}
                                </div>

                                <div className="form-group">
                                    <label htmlFor="cost">Cost ($)</label>
                                    <input
                                        id="cost"
                                        type="number"
                                        step="0.01"
                                        {...register("cost", { required: "Cost is required", min: { value: 0, message: "Cost must be positive" } })}
                                        className="form-input"
                                    />
                                    {errors.cost && <span className="error">{errors.cost.message}</span>}
                                </div>
                            </form>
                        </div>
                    </Modal>,
                    document.body
                )}
        </div>
    );
}



export default CarProfile;
