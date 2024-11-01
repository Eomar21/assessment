import { useState } from 'react'
import './App.css'
import axios from 'axios';


function App() {
    //const [path, setPath] = useState('')
    const [file, setFile] = useState('');
    const [parcels, setParcels] = useState([]);

    const handleFileUpload = (event: any) => {
        const uploadedFile = event.target.files[0];
        if (!uploadedFile) return;
        setFile(uploadedFile);
    };

    const loadParcels = async () => {
        if (!file) {
            console.error("No file selected");
            return;
        }

        // Use FormData to send the file
        const formData = new FormData();
        formData.append("file", file);

        try {
            const response = await axios.post("https://localhost:7105/parcelprocessor/processdto", formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            setParcels(response.data);
        } catch (error) {
            console.error("Error loading parcels:", error);
        }
    };


    return (
        <>
            <h1>Parcel Processor</h1>
            <h2>File Uploader</h2>
            <input type="file" accept=".xml" onChange={handleFileUpload} />
            <button onClick={loadParcels} >Load Parcels</button>
            <h3>Parcel Information:</h3>
            <div className="parcel-list">
                {parcels.map((parcel, index) => (
                    <div key={index} className="parcel-card">
                        <p><strong>Weight:</strong> {parcel.weight} kg</p>
                        <p><strong>Value:</strong> {parcel.value} Euro</p>
                        <p><strong>City:</strong> {parcel.receipient?.address?.city}</p>
                        <p><strong>Needs Signing:</strong> {parcel.needsSigning ? "Yes" : "No"}</p>
                        <p><strong>Departments Able to Handle:</strong> {parcel.department}</p>
                    </div>
                ))}
            </div>
        </>
    )
}

export default App
