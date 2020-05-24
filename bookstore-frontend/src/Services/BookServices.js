import axios from 'axios';
const getAllBooksURL = 'https://localhost:5001/api/Book';
const getBookCOuntURL = 'https://localhost:5001/api/Book/GetNumber_Books';

export const getAllBooksRequestMethod= async ()=>{
    const response = await axios.get(getAllBooksURL);
    return response;
}

export const getBookCountRequestMethod= async ()=>{
    const response = await axios.get(getBookCOuntURL);
    return response;
}