import { HashRouter as Router, Routes, Route } from 'react-router-dom'
import Home from './pages/Home'
import { CarProfile  } from './pages/CarProfile'
import { UserProfile } from './pages/UserProfile'
import { Welcome } from './pages/Welcome'
import { Layout } from './components/Layout'
import Login from './pages/Login';

function App() {
  return (
   <Router>
    <Routes>
    <Route path="/welcome" element={<Welcome/>}/>
      <Route element={<Layout/>}>
        <Route path="/" element={<Home/>}/>
        <Route path="/carprofile" element={<CarProfile/>}/>
        <Route path="/userprofile" element={<UserProfile/>}/>
        <Route path="/car/:carNickname/maintenance" element={<CarProfile/>}/>
      </Route>
      <Route path="/login" element={<Login />} />
    </Routes>
   </Router>
  )
}

export default App