import { HashRouter as Router, Routes, Route } from 'react-router-dom'
import Home from './pages/Home'
import { CarProfile  } from './pages/CarProfile'
import { UserProfile } from './pages/UserProfile'
import { Layout } from './components/Layout'

function App() {
  return (
   <Router>
    <Routes>
      <Route element={<Layout/>}>
        <Route path="/" element={<Home/>}/>
        <Route path="/carprofile" element={<CarProfile/>}/>
        <Route path="/userprofile" element={<UserProfile/>}/>
      </Route>
    </Routes>
   </Router>
  )
}

export default App