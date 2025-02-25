import axios from 'axios'

const addCartURL = 'https://localhost:5001/api/Cart/AddToCart';
const cartAddedCountURL = 'https://localhost:5001/api/Cart/NumOfBook';
const getCartValuesURL = 'https://localhost:5001/api/Cart/GetCartValue';
const deleteCartValueURL = 'https://localhost:5001/api/Cart/RemoveCart';
const addCustomerDetailsURL = 'https://localhost:5001/api/CustomerAddress/AddCustomerAddress';

export const AddCartRequestMethod = async (data)=>{
    const response = await axios.post(addCartURL,data);
    return response;
}

export const getCartAddedCountRequestMethod= async ()=>{
    const response = await axios.get(cartAddedCountURL);
    return response;
}

export const getCartValuesRequestMethod= async ()=>{
    const response = await axios.get(getCartValuesURL);
    return response;
}

export const deleteCartValueRequestMethod= async (id)=>{
    const response = await axios.delete(deleteCartValueURL,id);
    return response;
}

export const adCustomeDetailsRequestMethod= async (data)=>{
    const response = await axios.post(addCustomerDetailsURL,data);
    return response;
}
