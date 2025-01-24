import { useState } from 'react'
import './App.css'

function App() {
  const [proposals, setProposals] = useState([])

  const fetchProposals = async () => {
    try {
      const response = await fetch('/api/proposal')
      const data = await response.json()
      setProposals(data);
    } catch (error) {
      console.error(error)
    }
  }

  return (
    <>
    <div className="container">
      <button onClick={fetchProposals}>Fetch Proposals</button>
      <div className="proposals-container">
        {proposals.length > 0 ? (
          <ul>
            {proposals.map((proposal) => (
              <li key={proposal.id}>{proposal.projectName}</li>
            ))}
          </ul>
        ):(
          <p>No proposals found.</p>
        )}
      </div>
    </div>
    </>
  )
}

export default App
