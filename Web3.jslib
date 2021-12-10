 mergeInto(LibraryManager.library, {
   GetWalletAddress: function () {
     // get address from metamask
     var returnStr = web3.currentProvider.selectedAddress;
     var bufferSize = lengthBytesUTF8(returnStr) + 1;
     var buffer = _malloc(bufferSize);
     stringToUTF8(returnStr, buffer, bufferSize);
     return buffer;
   },

   GetBanlance: function () {
     Moralis.Web3API.account.getNativeBalance({ chain: 'bsc testnet', address: '0x4A19eFF337a4089d69956fBCd61FD5007a5Ee803' }).then(function (aaa) {
     console.log(aaa);
	 })
   },
 });