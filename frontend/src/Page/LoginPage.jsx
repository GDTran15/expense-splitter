

import { useState } from "react";

import FormComponent from "../Component/FormComponent";
import InputComponent from "../Component/InputComponent";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function LoginPage(){
    const navigate = useNavigate();
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [validationError,setValitionError] = useState({});
    const [error,setError] = useState("");
    

 
    const handleSubmit = async (e) => {
        e.preventDefault();
        setValitionError({});
        setError("");
        try{
        const res = await axios.post("https://localhost:7179/user/login",{
           
                Username: username,
                Password: password,
             
        });
        localStorage.setItem("user",JSON.stringify(res.data));
        console.log(res.data)
        
        navigate("/home");
    } catch (err)
    {if (typeof err.response.data == "string") {
        setError(err.response.data);
    } else {
        console.log(err.response.data.errors);
        setValitionError(err.response.data.errors);
    }
    }
    
    }

    return (
        
     <>
     
 
    <FormComponent 
       title="Login" 
       subTitle="Join Split That Thing community"
       optional="Create an account"
       linkTo={"/"}
       >
         <form onSubmit={handleSubmit} >
            
            <InputComponent 
            labelText="Username"
            changeHandle={(e) => setUsername(e.target.value)}
            inputType="text"
            inputValue={username}
            placeholderValue="Enter your username"
            validationError={validationError.Username}
            />
            <InputComponent 
            labelText="Password"
            changeHandle={(e) => setPassword(e.target.value)}
            inputType="password"
            inputValue={password}
            placeholderValue="Enter your password"
            validationError={validationError.Password}
            />
            <button type="submit" className="btn btn-warning w-100 mt-2">Login</button>
                    </form>
                    <p className="text-danger mt-3">{error !== "" ?  `*${error}` : ""}</p>
        </FormComponent>    

     </>   
    )
}