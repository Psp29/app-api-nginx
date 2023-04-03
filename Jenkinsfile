pipeline
{
	agent {
		docker {
			image 'mcr.microsoft.com/dotnet/sdk:3.1'
			args '-u root:root'
			} 
	}
	stages {
		stage('Restoring') {
			steps {
				sh 'dotnet restore'
				// sh 'npm cache clean --force'
			}
		}
		stage('Installing Depedencies...') {
			steps {
				// sh 'cd products_admin'
				sh 'dotnet tool install --global dotnet-ef --version 3.1'
				sh 'export PATH=$PATH:/root/.dotnet/tools'
			}
		}
		stage('DB Migration') {
			steps {
				sh 'dotnet-ef database update'
			}
		}
		stage('Building the code...') {
			steps {
				sh 'dotnet publish -c Release -o out'
			}
		}
	}
	post {
		always {
			archiveArtifacts artifacts: 'out/*', 
			onlyIfSuccessful: true
		}
	}
}
