import './App.css'
import CarItem from './components/CarItem'
import { dummyData } from './data/cars'

function App() {
  return (
   <main>
    <h1>
      Car Maintenance Tracker
      <div>
        <div>
          {dummyData.map(car => (
            <CarItem car={car}/>        
          ))}
        </div>
      </div>
    </h1>
   </main>
  )
}

export default App
