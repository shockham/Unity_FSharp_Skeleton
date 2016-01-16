UE_DLL=/Applications/Unity/Unity.app/Contents/Frameworks/Managed/UnityEngine.dll
DLL_TO=../dll/scripts.dll
SCRIPT_DIR=../scripts/
FSHARPC=/usr/local/bin/fsharpc

dll:
	$(FSHARPC) -r $(UE_DLL) -a $(SCRIPT_DIR)*.fs -o $(DLL_TO)
