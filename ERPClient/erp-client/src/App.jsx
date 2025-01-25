import { useState } from 'react'
import './App.css'
import NavBar from './NavBar'

function App() {
  const [proposals, setProposals] = useState([])

  const fetchProposals = async () => {
    try {
      const response = await fetch('/api/proposal') // Use the proxied path
      const data = await response.json()
      setProposals(data);
    } catch (error) {
      console.error('Error fetching proposals:', error)
    }
  }

  return (
    <>
      <NavBar />
    </>
  )
}

export default App