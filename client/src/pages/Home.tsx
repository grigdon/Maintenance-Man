import { Link } from "react-router-dom"

export function Home() {
    return (
        <>
            <h1>This is the home page</h1>
            <Link to="/">Home</Link>
            <Link to="/carprofile">Car Profile</Link>
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
*/}