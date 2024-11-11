import { useState } from 'react'
import './App.css'
import { useEffect } from 'react'

function App() {
  const [products, setProducts] = useState([])

  const getProducts = async () => {
    const res = await fetch('https://localhost:7237/api/products')
    const result = await res.json()
  
    setProducts(result.data)
  }

  useEffect(() => {
    getProducts()
  }, [])

    return (
      <>
        {
          products.map(product => (
            
            <div className="product">
              <h4>{product.title}</h4>
              <p>{product.description}</p>
              <p>{product.price}</p>
            </div>
          
          ))
        }
      </>
    )
}

export default App
