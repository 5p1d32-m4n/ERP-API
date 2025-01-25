import React from 'react'

function Header() {
  return (
    <header className="bg-blue-600 text-white">
      <nav className="container mx-auto p-4 flex justify-between items-center">
        <div className="text-lg font-bold">
          <a href="/">MyApp</a>
        </div>
        <div className="hidden md:flex space-x-4">
          <a href="/" className="hover:text-gray-300">Home</a>
          <a href="/about" className="hover:text-gray-300">About</a>
          <a href="/services" className="hover:text-gray-300">Services</a>
          <a href="/contact" className="hover:text-gray-300">Contact</a>
        </div>
        <div className="md:hidden">
          <button id="menu-button" className="focus:outline-none">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16m-7 6h7"></path>
            </svg>
          </button>
        </div>
      </nav>
      <div id="mobile-menu" className="md:hidden hidden">
        <a href="/" className="block px-4 py-2 hover:bg-blue-700">Home</a>
        <a href="/about" className="block px-4 py-2 hover:bg-blue-700">About</a>
        <a href="/services" className="block px-4 py-2 hover:bg-blue-700">Services</a>
        <a href="/contact" className="block px-4 py-2 hover:bg-blue-700">Contact</a>
      </div>
    </header>
  )
}

export default Header