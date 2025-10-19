

import { useState } from "react";

import FormComponent from "../Component/FormComponent";
import InputComponent from "../Component/InputComponent";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function LoginPage(){
    const navigate = useNavigate();
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
   
    const [error,setError] = useState("");
    

 
    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        try{
        const res = await axios.post("https://localhost:7179/user/login",{
           
                Username: username,
                Password: password,
             
        });
        localStorage.setItem("user",JSON.stringify(res.data));
        console.log(res.data)
        
        navigate("/home");
    } catch (error){
        setError(error.response.data)
    }
    
    }

    return (
        
     <>
     
 
    <FormComponent 
       title="Login" 
       subTitle="Join splitter community"
       optional="Create an account"
       >
         <form onSubmit={handleSubmit} >
            
            <InputComponent 
            labelText="Username"
            changeHandle={(e) => setUsername(e.target.value)}
            inputType="text"
            value={username}
            placeholderValue="Enter your username"
            />
            <InputComponent 
            labelText="Password"
            changeHandle={(e) => setPassword(e.target.value)}
            inputType="password"
            value={password}
            placeholderValue="Enter your password"
            />
            <button type="submit" className="btn btn-warning w-100 mt-2">Login</button>
                    </form>
                    <p className="text-danger mt-3">{error !== "" ?  `*${error}` : ""}</p>
        </FormComponent>    

     </>   
    )
}