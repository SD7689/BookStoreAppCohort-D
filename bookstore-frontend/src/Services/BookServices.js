import axios from 'axios';
const getAllBooksURL = 'https://localhost:5001/api/Book/GetAllBook';
const getBookCOuntURL = 'https://localhost:5001/api/Book/NumOfBooks';

export const getAllBooksRequestMethod= async ()=>{
    const response = await axios.get(getAllBooksURL);
    return response;
}

export const getBookCountRequestMethod= async ()=>{
    const response = await axios.get(getBookCOuntURL);
    return response;
}