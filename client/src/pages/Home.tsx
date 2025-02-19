import Popup from "reactjs-popup"
import 'reactjs-popup/dist/index.css'

export function Home() {
    return (
      <>
        <Popup trigger={<button>+</button>} position="right center"
          modal nested> {
            <div>
              Add Vehicle Information Here
            </div>
          }
          <div>car_name</div>
          <div>car_type_etc</div>
        </Popup>
      </>
    )
}

{/*
    import { dummyData } from './data/cars'
    <main>
    <h1> Car Maintenance Tracker </h1>
      <div>
        {dummyData.slice(0, 3).map((car, index) => (
          <button key={index} title={car.name}>{car.name}</button>
        ))}
      </div>
   </main>

   <div
      className="modal show"
      style={{ display: 'block', position: 'initial' }}
    >
      <Modal.Dialog>
        <Modal.Header closeButton>
          <Modal.Title>Modal title</Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <p>Modal body text goes here.</p>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary">Close</Button>
          <Button variant="primary">Save changes</Button>
        </Modal.Footer>
      </Modal.Dialog>
    </div>
  );

*/}