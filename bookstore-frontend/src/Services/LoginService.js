import axios from 'axios'

export async function AddUserRequestMethod(Email_id, password) {
    try {
        return axios.get('https://localhost:5001/api/Customer/CustmorLogin?Email_Id=' + Email_id + '&Password=' + password)
            .then(response => {
                return response
            })
    }
    catch (error) {
        console.log("error while login Employee" + error)
        return Promise.resolve(false)
    }
}