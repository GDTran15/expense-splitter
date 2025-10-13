import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';

import RegisterPage from './Page/RegisterPage.jsx'
import LoginPage from './Page/LoginPage.jsx';
import HomePage from './Page/HomePage.jsx';
import { createBrowserRouter , RouterProvider } from 'react-router-dom'

const router = createBrowserRouter([
  { path:"/", element: <RegisterPage/>},
  { path:"/login", element: <LoginPage/>},
  { path:"/home", element: <HomePage/>}
])

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>,
)
