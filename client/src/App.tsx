import { HashRouter as Router, Routes, Route } from 'react-router-dom'
import { Home } from './pages/Home'
import { CarProfile  } from './pages/CarProfile'

function App() {
  return (
   <Router>
    <Routes>
      <Route path="/" element={<Home/>}/>
      <Route path="/carprofile" element={<CarProfile/>}/>
    </Routes>
   </Router>
  )
}

export default App