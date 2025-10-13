import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';

import RegisterPage from './Page/RegisterPage.jsx'
import { createBrowserRouter , RouterProvider } from 'react-router-dom'

const router = createBrowserRouter([
  { path:"/", element: <RegisterPage/>}
])

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>,
)
