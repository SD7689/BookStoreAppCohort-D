import axios from 'axios'

const addUserURL = 'https://localhost:5001/api/Login/Login';

export const AddUserRequestMethod = async (data)=>{
    const response = await axios.post(addUserURL,data);
    return response;
}