import React from 'react'
import './App.css'
import CarItem from './components/CarItem'
import { dummyData } from './data/cars'

function App() {
  return (
   <main>
    <h1> Car Maintenance Tracker </h1>
      <div>
        {dummyData.slice(0, 3).map((car, index) => (
          <button key={index} title={car.name}>{car.name}</button>
        ))}
      </div>
   </main>
  )
}

export default App
