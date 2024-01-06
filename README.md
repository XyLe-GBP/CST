# CST - (Chunithm Song Tool)
GUI front-end based tool for creating custom CRI ADX2 for CHUNITHM.

## What is this?

It can extract and extract audio created in CRI ADX2 format, synchronize and edit it, and replace it with the original audio.  

## Usage

This application is a front-end application.  
It does not work by itself and requires the following in order to work.  

* [SonicAudioTools](https://github.com/blueskythlikesclouds/SonicAudioTools/releases)  
* [DereTore](https://github.com/OpenCGSS/DereTore/releases)  

After downloading the above two files, create a 'res' folder in the same location as the application and place the SonicAudioTools binary in 'res\sat\'.  
Similarly, put the DereTore binary inside 'res\dt\'.  
  
The file structure is as follows:  
```
res
├─dt
│  └─Release
│    └─  acb2wavs.exe ... etc
│
└─sat
  └─  AcbEditor.exe ... etc
```
If the file is not placed correctly, the application returns an error.  

### Licence
MIT.
