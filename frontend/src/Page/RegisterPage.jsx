

import { useState } from "react";

import FormComponent from "../Component/FormComponent";
import InputComponent from "../Component/InputComponent";
import axios from "axios";

export default function RegisterPage(){
    const [name,setName] = useState("");
    const [gmail,setGmail] = useState("");
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [phone,setPhone] = useState("");
    const [error,setError] = useState("");
    

 
    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        try{
        const res = await axios.post("https://localhost:7159/user/register",{
             Name: name,
                Username: username,
                Password: password,
                Email: gmail,   
                Phone: phone
        });
     setName(""); setUsername(""); setPassword(""); setGmail(""); setPhone("");
        alert(res.data);
    } catch (error){
        setError(error.response.data)
    }
    
    }

    return (
        
     <>
     
 
    <FormComponent 
       title="Create Your Account" 
       subTitle="Join splitter community"
       optional="Already have an account? Sign in"
       linkTo="/login"
       >
         <form onSubmit={handleSubmit} >
              
            <InputComponent 
            labelText="Name"
            changeHandle={(e) => setName(e.target.value)}
            inputType="text"
            inputValue={name}
            placeholderValue="Enter your name"
            />
            
            <InputComponent 
            labelText="Gmail"
            changeHandle={(e) => setGmail(e.target.value)}
            inputType="email"
            value={gmail}
            placeholderValue="Enter your gmail"
            />
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
            <InputComponent 
            labelText="Phone"
            changeHandle={(e) => setPhone(e.target.value)}
            inputType="text"
            inputValue={phone}
            placeholderValue="Enter your phone number"
            />
            <button type="submit" className="btn btn-warning w-100 mt-2">Register</button>
                    </form>
                    <p className="text-danger mt-3">{error !== "" ?  `*${error}` : ""}</p>
        </FormComponent>    

     </>   
    )
}